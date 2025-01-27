# Chest System 💸

## Overview

This project implements a dynamic chest system for Unity with the following key features:

**Currencies**: Coins 💰 and Gems 💎.

**Chest Types**: Multiple types of chests with flexible reward values and timers using Scriptable Objects.

**Chest Slots**: Scrollable dynamic list for managing chests with a minimum of 4 slots.

**Chest State System**: Managed using the State Pattern.

**Dynamic Timer and Gem Cost**: Timer management and gem-based unlocking cost calculations.

The project uses MVC architecture for clear separation of concerns and Service Locator for dependency management.

---

## Features

### 1. Currencies

Coins 💰: Primary currency used to determine rewards from chests.

Gems 💎: Secondary currency used to unlock chests instantly by skipping timers.

### 2. Chest Types

Details:

Four chest types: Common, Rare, Epic, and Legendary.

Rewards (coins and gems) are dynamically generated within a range.

Unlocking timers vary based on chest type.

Flexibility: All chest properties (rewards, timers, etc.) are managed through **Scriptable Objects** to allow designers to modify values without altering code.

#### Chest Properties

| Chest Type    | Rewards                        | Timer   |
| ------------- | ------------------------------ | ------- |
| **Common**    | Coins: 100-200 💰, Gems: 10-20 💎 | 1 minute |
| **Rare**      | Coins: 300-500 💰, Gems: 20-40 💎 | 5 minutes |
| **Epic**      | Coins: 600-800 💰, Gems: 45-60 💎 | 10 minutes  |
| **Legendary** | Coins: 1000-1200 💰, Gems: 80-100 💎 | 20 minutes |

### 3. Chest Slots

Scrollable List:

Dynamic list of chest slots with a minimum of 4 slots.

Button to generate random chests in empty slots.

Slot Full Handling:

Pop-up appears if all slots are full. ⚠️

**Chest Management**

Chests added to slots remain locked until activated.

Pop-Up Options when clicking on a locked chest:

Start Timer ⏳: Begins the chest unlock timer.

Unlock with Gems 💎: Instantly unlocks the chest by spending gems.

Rewards are based on chest type and can be collected when the timer finishes.

### 4. Chest States

Locked 🔒: Chest is added but the timer has not started.

Unlocking ⏳: Timer is running for the chest.

Unlocked ✅: Timer has finished; chest can be tapped to collect rewards.

**State Management**

Implemented using the **State Pattern** for clean and maintainable transitions between chest states.

### 5. Unlocking Rules

i. Only one chest can be unlocking at a time.

ii. Unlocking can also be done instantly using gems.

**Unlocking with Gems**

Gem Cost Calculation:

i. 1 Gem 💎 for every 10 minutes remaining on the timer.

ii. Cost reduces as the timer counts down.

iii. Always use ceil for calculation (e.g., 11 mins = 2 Gems 💎, 29 mins = 3 Gems 💎).

Pop-Up Handling:

If insufficient gems, a pop-up informs the player. ⚠️

---

## Implementation Details

### Design Patterns

**MVC Architecture**:

1. Ensures clear separation between the game logic (Model), user interface (View), and user interaction (Controller).

2. Helps maintain scalability and readability.

**Service Locator**:

Used for dependency injection and communication between scripts (e.g., Pop-Up Manager, Timer Manager).

**State Pattern**:

Simplifies the management of chest states (Locked, Unlocking, Unlocked).

### Scriptable Objects

1. All chest data (type, rewards, timers, etc.) is stored in Scriptable Objects to allow designers to make adjustments without altering code.

2. Similarly, all popup data like popup type and popup view is stored in Scriptable Object.

---

## Usage Instructions

**Adding Chests**:

Click the Generate Chest button ➕ to add a random chest to an empty slot.

**Starting Timer**:

Click on a locked chest 🔒 and select Start Timer ⏳ in the pop-up.

**Unlocking with Gems**:

Click on a locked or unlocking chest ⏳ and select Unlock with Gems 💎 in the pop-up.

**Collecting Rewards**:

Tap on an unlocked chest ✅ to collect the rewards.

**Handling Full Slots**:

If all slots are full, a pop-up will appear to notify the player. ⚠️

---

## Flexibility

1. Designers can easily adjust reward ranges, timers, and gem costs using the Scriptable Object system.

2. Additional chest types and properties can be added without major code changes.

---

## Play here



--

## Watch here

https://www.loom.com/share/d929846aa8f641989b07f1bce0307dfa?sid=44fae612-a98e-4822-bf49-6fb24ecee460
