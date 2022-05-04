using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

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

            

            // Display current location name and description
            rtbLocation.Text = newRoom.Name + Environment.NewLine;
            rtbLocation.Text += newRoom.Description + Environment.NewLine;

            // Completely heal the player
            _player.CurrentHP = _player.MaxHP;

            // Update Hit Points in UI
            lblHitPoints.Text = _player.CurrentHP.ToString();

            // Does the location have a quest?
            if (newRoom.QuestAvailableInRoom != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasQuest(newRoom.QuestAvailableInRoom);
                bool playerAlreadyCompletedQuest = _player.CompletedQuest(newRoom.QuestAvailableInRoom);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasQuestCompletionItems(newRoom.QuestAvailableInRoom);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newRoom.QuestAvailableInRoom.Name + "' quest." + Environment.NewLine;
                            ScrollToBottomOfMessages();

                            // Remove quest items from inventory
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

                            // Add the reward item to the player's inventory
                            _player.AddItemToInvent(newRoom.QuestAvailableInRoom.RewardItem);

                            // Mark the quest as completed
                            _player.isQuestCompleted(newRoom.QuestAvailableInRoom);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
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

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newRoom.QuestAvailableInRoom));
                }
            }

            // Does the location have a monster?
            if (newRoom.EnemyInRoom != null)
            {
                rtbMessages.Text += "You see a " + newRoom.EnemyInRoom.Name + Environment.NewLine;
                ScrollToBottomOfMessages();

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Enemy standardMonster = Dungeon.EnemyByID(newRoom.EnemyInRoom.ID);

                _currentEnemy = new Enemy(standardMonster.ID, standardMonster.Name, standardMonster.MaxDamage,
                    standardMonster.RewardXP, standardMonster.RewardGold, standardMonster.CurrentHP, standardMonster.MaxHP);

                foreach (LootItem lootItem in standardMonster.LootTable)
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

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventItem inventoryItem in _player.Invent)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

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
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
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
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
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

            // Determine the amount of damage to do to the monster
            int damageToMonster = RNG.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentEnemy.CurrentHP -= damageToMonster;

            // Display message
            rtbMessages.Text += "You hit the " + _currentEnemy.Name + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;
            ScrollToBottomOfMessages();

            // Check if the monster is dead
            if (_currentEnemy.CurrentHP <= 0)
            {
                // Monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated the " + _currentEnemy.Name + Environment.NewLine;

                // Give player experience points for killing the monster
                _player.XP += _currentEnemy.RewardXP;
                rtbMessages.Text += "You receive " + _currentEnemy.RewardXP.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                _player.Gold += _currentEnemy.RewardGold;
                rtbMessages.Text += "You receive " + _currentEnemy.RewardGold.ToString() + " gold" + Environment.NewLine;

                // Get random loot items from the monster
                List<InventItem> lootedItems = new List<InventItem>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in _currentEnemy.LootTable)
                {
                    if (RNG.NumberBetween(1, 100) <= lootItem.DropRate)
                    {
                        lootedItems.Add(new InventItem(lootItem.Details, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
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

                // Add the looted items to the player's inventory
                foreach (InventItem inventoryItem in lootedItems)
                {
                    _player.AddItemToInvent(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                        ScrollToBottomOfMessages();
                    }
                }

                // Refresh player information and inventory controls
                lblHitPoints.Text = _player.CurrentHP.ToString();
                lblGold.Text = _player.Gold.ToString();
                lblExperience.Text = _player.XP.ToString();
                lblLevel.Text = _player.Level.ToString();

                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();

                // Add a blank line to the messages box, just for appearance.
                rtbMessages.Text += Environment.NewLine;

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(_player.CurrentRoom);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MaxDamage);

                // Display message
                rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player
                _player.CurrentHP -= damageToPlayer;

                // Refresh player data in UI
                lblHitPoints.Text = _player.CurrentHP.ToString();

                if (_player.CurrentHP <= 0)
                {
                    // Display message
                    rtbMessages.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                    // Move player to "Home"
                    MoveTo(Dungeon.RoomByID(Dungeon.ROOM_ID_DUNGEON_ENTRANCE));
                }
            }
            ScrollToBottomOfMessages();
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingItem potion = (HealingItem)cboPotions.SelectedItem;

            // Add healing amount to the player's current hit points
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

            // Display message
            rtbMessages.Text += "You drink a " + potion.Name + Environment.NewLine;

            // Monster gets their turn to attack

            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RNG.NumberBetween(0, _currentEnemy.MaxDamage);

            // Display message
            rtbMessages.Text += "The " + _currentEnemy.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

            // Subtract damage from player
            _player.CurrentHP -= damageToPlayer;

            if (_player.CurrentHP <= 0)
            {
                // Display message
                rtbMessages.Text += "The " + _currentEnemy.Name + " killed you." + Environment.NewLine;

                // Move player to "Home"
                MoveTo(Dungeon.RoomByID(Dungeon.ROOM_ID_DUNGEON_ENTRANCE));
            }

            // Refresh player data in UI
            lblHitPoints.Text = _player.CurrentHP.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
        }

        private void ScrollToBottomOfMessages()
        {
            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblInventory_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblExperience_Click(object sender, EventArgs e)
        {

        }

        private void lblGold_Click(object sender, EventArgs e)
        {

        }

        private void lblHitPoints_Click(object sender, EventArgs e)
        {

        }

        private void lblLevel_Click(object sender, EventArgs e)
        {

        }

        private void lblMovement_Click(object sender, EventArgs e)
        {

        }

        private void btnViewInventory_Click(object sender, EventArgs e)
        {
            dgvInventory.BringToFront();
            lblInventory.BringToFront();
        }

        private void btnViewQuests_Click(object sender, EventArgs e)
        {
            dgvQuests.BringToFront();
            lblQuests.BringToFront();
        }

        private void lblQuests_Click(object sender, EventArgs e)
        {

        }
    }
}
