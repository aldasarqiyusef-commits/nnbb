# Unity Game System - Build Guide

## 📦 Building the Game

This guide will help you build the game into an executable file.

### Prerequisites
- Unity 2020.3 LTS or higher
- The project with all scripts properly set up

### Build Steps

#### 1. Configure Player Settings
```
File → Build Settings → Player Settings
```

#### 2. Add Scenes
```
File → Build Settings
- Click "Add Open Scenes"
```

#### 3. Choose Build Platform
```
File → Build Settings
- Select your target platform:
  ✓ Windows (Recommended)
  ✓ Mac
  ✓ Linux
  ✓ WebGL (Browser)
```

#### 4. Build Project
```
File → Build and Run
```

Or:
```
File → Build
- Choose folder location
- Wait for build to complete
```

### Windows Build Output
After building, you'll get:
- `.exe` file (executable)
- `_Data` folder (game resources)
- Run the `.exe` to play!

### System Requirements

**Minimum:**
- OS: Windows 7 or higher
- RAM: 2GB
- GPU: Any modern GPU
- Processor: Dual Core 2GHz+

**Recommended:**
- OS: Windows 10/11
- RAM: 4GB+
- GPU: Dedicated Graphics
- Processor: Quad Core 2.5GHz+

### Troubleshooting

#### Build fails?
1. Check Console for errors (Window → General → Console)
2. Ensure all scripts compile correctly
3. Check that CharacterController is assigned to Player

#### Game crashes on launch?
1. Verify Player GameObject has:
   - CharacterController component
   - SimpleMove script
   - PlayerController script
2. Verify GameManager exists in scene
3. Check Console for error messages

#### Performance issues?
1. Reduce graphical quality
2. Disable shadow on lights
3. Reduce draw calls

---

## 🎮 Ready to Build?

1. Open your project in Unity
2. Follow the steps above
3. Build and enjoy! 🚀

For detailed information, visit: [Unity Build Guide](https://docs.unity3d.com/Manual/BuildSettings.html)