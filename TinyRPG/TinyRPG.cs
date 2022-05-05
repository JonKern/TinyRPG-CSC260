using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TinyRPG
{
    public partial class TinyRPG : Form
    {
        private void TinyRPG_Load(object sender, EventArgs e)
        {

        }
        private Player _player;
        private Enemy _currentEnemy;

        public TinyRPG()
        {
            InitializeComponent();

            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(Dungeon.RoomByID(Dungeon.ROOM_ID_DUNGEON_ENTRANCE));
            _player.Invent.Add(new InventItem(Dungeon.ItemByID(Dungeon.ITEM_ID_TRUSTY_DAGGER), 1));

            lblHitPoints.Text = _player.CurrentHP.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExperience.Text = _player.XP.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentRoom.RoomForward);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentRoom.RoomRight);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentRoom.RoomBack);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentRoom.RoomLeft);
        }

        private void MoveTo(DungeonRooms newRoom)
        {
            //Does the location have any required items
            if (!_player.HasRequiredItemToEnterThisLocation(newRoom))
            {
                rtbMessages.Text += "You must have a " + newRoom.ItemRequiredForEntry.Name + " to enter this location." + Environment.NewLine;
                ScrollToBottomOfMessages();
                return;
            }

            // Update the player's current location
            _player.CurrentRoom = newRoom;

            // Show/hide available movement buttons
            if (newRoom.RoomForward != null)
            {
                btnForward.Enabled = true;
                btnForward.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
                btnForward.Enabled = false;

            if (newRoom.RoomRight != null)
            {
                btnRight.Enabled = true;
                btnRight.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
                btnRight.Enabled = false;

            if (newRoom.RoomBack != null)
            {
                btnBack.Enabled = true;
                btnBack.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
                btnBack.Enabled = false;

            if (newRoom.RoomLeft != null)
            {
                btnLeft.Enabled = true;
                btnLeft.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
                btnLeft.Enabled = false;

            

            // Display current room name and description
            rtbRoom.Text = newRoom.Name + Environment.NewLine;
            rtbRoom.Text += newRoom.Description + Environment.NewLine;

            // Heal player to full
            _player.CurrentHP = _player.MaxHP;

            // Update HP in UI
            lblHitPoints.Text = _player.CurrentHP.ToString();

            // Check if room has quest
            if (newRoom.QuestAvailableInRoom != null)
            {
                // Check if the player already has quest and it's been completed
                bool playerAlreadyHasQuest = _player.HasQuest(newRoom.QuestAvailableInRoom);
                bool playerAlreadyCompletedQuest = _player.CompletedQuest(newRoom.QuestAvailableInRoom);

                // Check if the player already hasquest
                if (playerAlreadyHasQuest)
                {
                    // If player has not completed the quest yet...
                    if (!playerAlreadyCompletedQuest)
                    {
                        // Check if player has all the items needed to complete it
                        bool playerHasAllItemsToCompleteQuest = _player.HasQuestCompletionItems(newRoom.QuestAvailableInRoom);

                        // Player has all items needed to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {                            
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newRoom.QuestAvailableInRoom.Name + "' quest." + Environment.NewLine;
                            ScrollToBottomOfMessages();

                            // Remove quest items from invent
                            _player.RemoveQuestCompletionItems(newRoom.QuestAvailableInRoom);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newRoom.QuestAvailableInRoom.RewardXP.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newRoom.QuestAvailableInRoom.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newRoom.QuestAvailableInRoom.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;
                            ScrollToBottomOfMessages();

                            _player.XP += newRoom.QuestAvailableInRoom.RewardXP;
                            _player.Gold += newRoom.QuestAvailableInRoom.RewardGold;

                            // Add the reward item to player's invent
                            _player.AddItemToInvent(newRoom.QuestAvailableInRoom.RewardItem);

                            // Mark the quest as completed
                            _player.isQuestCompleted(newRoom.QuestAvailableInRoom);
                        }
                    }
                }
                else
                {
                    // Player does not already have the quest

                    // Display messages
                    rtbMessages.Text += "You receive the " + newRoom.QuestAvailableInRoom.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newRoom.QuestAvailableInRoom.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    ScrollToBottomOfMessages();
                    foreach (QuestCompletionItem qci in newRoom.QuestAvailableInRoom.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    // Add the quest to player's quest list
                    _player.Quests.Add(new PlayerQuest(newRoom.QuestAvailableInRoom));
                }
            }

            // Does the room have an enemy?
            if (newRoom.EnemyInRoom != null)
            {
                rtbMessages.Text += "You see a " + newRoom.EnemyInRoom.Name + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Spawn a new enemy, using the values from the standard enemy in the Dungeon.Enemy list
                Enemy standardEnemy = Dungeon.EnemyByID(newRoom.EnemyInRoom.ID);

                _currentEnemy = new Enemy(standardEnemy.ID, standardEnemy.Name, standardEnemy.MaxDamage,
                    standardEnemy.RewardXP, standardEnemy.RewardGold, standardEnemy.CurrentHP, standardEnemy.MaxHP);

                foreach (LootItem lootItem in standardEnemy.LootTable)
                {
                    _currentEnemy.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentEnemy = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }

            // Refresh player's invent
            UpdateInventListInUI();

            // Refresh player's quests
            UpdateQuestListInUI();

            // Refresh player's weapons
            UpdateWeaponListInUI();

            // Refresh player's potions
            UpdatePotionListInUI();
        }

        private void UpdateInventListInUI()
        {
            dgvInvent.RowHeadersVisible = false;

            dgvInvent.ColumnCount = 2;
            dgvInvent.Columns[0].Name = "Name";
            dgvInvent.Columns[0].Width = 170;
            dgvInvent.Columns[1].Name = "#";

            dgvInvent.Rows.Clear();

            foreach (InventItem inventItem in _player.Invent)
            {
                if (inventItem.Quantity > 0)
                {
                    dgvInvent.Rows.Add(new[] { inventItem.Details.Name, inventItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 170;
            dgvQuests.Columns[1].Name = "Completed?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventItem inventoryItem in _player.Invent)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // If player doesn't have any weapons, hide the Use button and weapon combobox
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingItem> healingPotions = new List<HealingItem>();

            foreach (InventItem inventoryItem in _player.Invent)
            {
                if (inventoryItem.Details is HealingItem)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingItem)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // If player doesn't have any potions, hide the hide the Use button and potions combobox
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;

            // Determine the amount of damage to do to the enemy
            int damageToEnemy = RNG.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentEnemy.CurrentHP -= damageToEnemy;

            // Display message
            rtbMessages.Text += "You hit the " + _currentEnemy.Name + " for " + damageToEnemy.ToString() + " points." + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Check if the enemy is dead (below 1 HP)
            if (_currentEnemy.CurrentHP <= 0)
            {
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _currentEnemy.Name + Environment.NewLine;

                // Give player XP for killing enemy
                _player.XP += _currentEnemy.RewardXP;
                rtbMessages.Text += "You receive " + _currentEnemy.RewardXP.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the enemy 
                _player.Gold += _currentEnemy.RewardGold;
                rtbMessages.Text += "You receive " + _currentEnemy.RewardGold.ToString() + " gold" + Environment.NewLine;

                // Get random loot items from the enemy drop table
                List<InventItem> lootedItems = new List<InventItem>();

                // Add items to the lootedItems list, based on a random number to set drop rate
                foreach (LootItem lootItem in _currentEnemy.LootTable)
                {
                    if (RNG.NumberBetween(1, 100) <= lootItem.DropRate)
                    {
                        lootedItems.Add(new InventItem(lootItem.Details, 1));
                    }
                }

                // If no items were randomly selected, then choose from the default loot table.
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in _currentEnemy.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new InventItem(lootItem.Details, 1));
                        }
                    }
                }

                // Add looted items to the player's invent
                foreach (InventItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInvent(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                        
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                        
                    }
                    ScrollToBottomOfMessages();
                }

                // Refresh player info and invent controls
                lblHitPoints.Text = _player.CurrentHP.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.XP.ToString();
                lblLevel.Text = _player.Level.ToString();

                UpdateInventListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a new to the message box
                rtbMessages.Text += Environment.NewLine;

                // Move player to current room (heals player and spawns a new enemy)
                // **NOTE** THIS IS FOR PRESENTATION ONLY, RE-EXAMINE HOW TO HANDLE
                // THIS IN THE FUTURE
                MoveTo(_player.CurrentRoom);
            }
            else
            {
                // Enemy is still alive

                // Set the damage the enemy does to the player
                int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MaxDamage);
               
                rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player HP
                _player.CurrentHP -= damageToPlayer;

                // Refresh HP in UI
                lblHitPoints.Text = _player.CurrentHP.ToString();

                if (_player.CurrentHP <= 0)
                {
                    rtbMessages.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                    // Move player to Dungeon Entrance
                    // **NOTE** PLAY KEEPS ALL ITEMS AND QUESTS ON DEATH, RE-EXAMINE
                    // HOW TO HANDLE THIS IN THE FUTURE. MAYBE LOSE KEY ITEMS?
                    MoveTo(Dungeon.RoomByID(Dungeon.ROOM_ID_DUNGEON_ENTRANCE));
                }
            }
            ScrollToBottomOfMessages();
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingItem potion = (HealingItem)cboPotions.SelectedItem;

            // Add healing amount to the player's current HP
            _player.CurrentHP = (_player.CurrentHP + potion.AmountToHeal);

            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (_player.CurrentHP > _player.MaxHP)
            {
                _player.CurrentHP = _player.MaxHP;
            }

            // Remove the potion from the player's inventory
            foreach (InventItem ii in _player.Invent)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }

            // Print message
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MaxDamage);

            // Print message
            rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            // Subtract damage from player
            _player.CurrentHP -= damageToPlayer;

            if (_player.CurrentHP <= 0)
            {
                // Print message
                rtbMessages.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                // Move player to Dungeon Entrance
                MoveTo(Dungeon.RoomByID(Dungeon.ROOM_ID_DUNGEON_ENTRANCE));
            }

            // Refresh UI
            lblHitPoints.Text = _player.CurrentHP.ToString();
            UpdateInventListInUI();
            UpdatePotionListInUI();

            ScrollToBottomOfMessages();
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            dgvInvent.BringToFront();
            lblInvent.BringToFront();
        }

        private void btnViewQuests_Click(object sender, EventArgs e)
        {
            dgvQuests.BringToFront();
            lblQuests.BringToFront();
        }

        private void rtbMessages_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
