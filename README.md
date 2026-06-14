# Unity Game System

A professional Unity game system with character movement, player data management, and game mechanics.

## 🎮 Features

- ✅ Smooth character movement system
- ✅ Sprint functionality (Shift key)
- ✅ Jump mechanics (Space key)
- ✅ Player data management (role, money, health, level)
- ✅ Health and healing system
- ✅ Experience and leveling system
- ✅ Attack system with cooldown
- ✅ Event system for UI updates
- ✅ Gravity simulation
- ✅ Animation support
- ✅ Game Manager (Singleton pattern)

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── PlayerData.cs          # Player information management
│   ├── SimpleMove.cs          # Enhanced movement system
│   ├── PlayerController.cs    # Player input and mechanics
│   └── GameManager.cs         # Game state management
└── README.md
```

## 🎯 Scripts Overview

### PlayerData.cs
Manages all player information with validation and events:
- Properties: Name, Role, Money, Health, Experience, Level
- Methods: AddMoney, SpendMoney, TakeDamage, Heal, AddExperience
- Events: OnMoneyChanged, OnHealthChanged, OnLevelUp

### SimpleMove.cs
Enhanced character movement controller:
- Smooth movement based on input
- Sprint (Shift) and jump (Space) support
- Gravity and ground detection
- Animation integration
- Configurable speeds

### PlayerController.cs
Integrates movement with gameplay mechanics:
- Attack system (E key)
- Healing (H key)
- Damage handling
- Money collection

### GameManager.cs
Centralized game management:
- Singleton pattern
- Player management
- Game pause/resume (Esc key)
- Game over handling

## ⌨️ Controls

| Key | Action |
|-----|--------|
| W/A/S/D | Move |
| Left Shift | Sprint |
| Space | Jump |
| E | Attack |
| H | Heal |
| Esc | Pause/Resume |

## 🚀 Getting Started

1. **Create a new Unity project** (2020.3+)
2. **Copy the Scripts folder** to your Assets
3. **Create player setup:**
   - Create a GameObject with CharacterController component
   - Add Animator component (optional)
   - Attach `SimpleMove` script
   - Attach `PlayerController` script
4. **Game Manager setup:**
   - Create empty GameObject
   - Add `GameManager` script
5. **Configure in Inspector:**
   - Adjust movement speeds
   - Configure jump force
   - Set combat parameters
6. **Play and enjoy!** 🎮

## 📊 Player System

### Health System
- Default: 100 HP
- Damage: Reduces health
- Healing: Restores health
- Death: Triggered at 0 HP

### Experience & Leveling
- XP Required: Level × 100
- Level Rewards: +10 Max Health
- Automatic leveling on XP threshold

### Economy
- Starting Money: 100
- Add/Spend: Full control
- Validation: Can't go below 0

## 🔧 Customization

All parameters are adjustable in the Inspector:

**Movement:**
- `speed`: Normal movement speed (default: 6)
- `sprintSpeed`: Sprint speed (default: 12)
- `jumpForce`: Jump height (default: 5)

**Combat:**
- `attackDamage`: Damage per attack (default: 10)
- `attackCooldown`: Time between attacks (default: 1s)

## 🎓 Code Quality

- ✅ Full Arabic comments
- ✅ Proper encapsulation
- ✅ Event-driven architecture
- ✅ Error handling
- ✅ Debug logs
- ✅ Serialized fields for inspector control

## 🔮 Future Enhancements

- [ ] Enemy AI system
- [ ] Sound effects and music
- [ ] UI system (Health bar, money display, XP bar)
- [ ] Inventory system
- [ ] Save/Load system
- [ ] Multiplayer support
- [ ] Mobile controls
- [ ] Particle effects
- [ ] Combat animations
- [ ] Dialog system

## 📝 License

MIT License - Feel free to use and modify!

## 👨‍💻 Author

Created for Unity game development

---

**Ready to make games? Let's go! 🚀**
