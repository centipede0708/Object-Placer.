# 🚛 Object Placer – 3D Logistics Challenge

**Object Placer** is a 3D **third-person, physics-based logistics game** where precision, timing, and awareness decide your success.  
Your job? Pick up scattered packages and cylinders, rotate them properly, and load them onto the back of a truck — all within a strict time limit.

Each new level keeps you in the same familiar location but raises the stakes — **less time, trickier shapes, and tighter margins**.  
And if you prove yourself through all 5 levels… there’s a **hidden 6th level** waiting.

---

## 🎮 Gameplay Overview

You play as a worker in a restricted loading zone.  
Your mission is to **pick, rotate, and place objects** on the truck bed before the timer runs out.

- Every level introduces **smaller time limits** and **larger or more irregular objects**.  
- If you **leave the work area**, a **10-second countdown** begins — return in time or the game ends.  
- **Perfect object placement** is key — misaligned or dropped items can cost you valuable seconds.

---

## 🧩 Core Features

| Feature | Description |
|----------|-------------|
| 🧍 Third-Person Gameplay | Full movement control with a follow camera. |
| 📦 Physics-Based Objects | All packages and cylinders react to physics and collision forces. |
| 🔄 Object Rotation System | Rotate items to fit them correctly on the truck bed. |
| 🕒 Dynamic Timers | Each level has a reduced time limit for added pressure. |
| ⚙️ Progressive Difficulty | Object size, weight, and shape change with each level. |
| 🚫 Boundary Detection | Leaving the work zone triggers a 10-second fail timer. |
| 🚚 Truck Loading Mechanic | Load all items to win the level. |
| 🔓 Hidden Level | Unlockable secret stage with extreme difficulty. |

---

## 🧱 Level Design

| Level | Location | Difficulty | Time Limit | Object Traits |
|--------|-----------|-------------|-------------|----------------|
| 1 | Warehouse Yard | Easy | 3:00 | Small boxes and short cylinders |
| 2 | Same Yard | Moderate | 2:30 | Slightly larger items |
| 3 | Same Yard | Challenging | 2:00 | Longer cylinders, tighter fits |
| 4 | Same Yard | Hard | 1:30 | Heavier, bulkier items |
| 5 | Same Yard | Extreme | 1:00 | Oversized packages, precision needed |
| 🔒 Hidden Level | ??? | Secret | 0:45 | Mixed object chaos + no mistakes allowed |

> 🏗️ The **location never changes** — it’s the **rules that evolve**, forcing mastery of control, awareness, and timing.

---

## 🎯 Objective

- Collect all required objects.  
- Rotate and place them properly on the truck bed.  
- Finish before the timer expires.  
- Stay inside the work area — or face a 10-second fail timer.

---

## 🕹️ Controls

| Action | Key |
|---------|-----|
| Move | `W / A / S / D` |
| Look Around | Mouse |
| Pick Up / Drop | `left mousr click` |
| Rotate Object | `A and D after left mouse click` |
| Sprint | `Shift` |
| Jump | `Space` |
| Pause / Quit | `Esc` |

---

## 🧠 Game Logic Summary

1. Player spawns inside the work area.  
2. Timer starts ticking.  
3. Pick up object → carry → rotate → place on truck.  
4. Leave boundary → 10-second countdown triggers.  
5. Return in time → countdown resets; otherwise → fail.  
6. Complete all placements → next level unlocked.  
7. After Level 5 → unlock **Hidden Level (Level X)**.

---

## ⚙️ Technical Info

| Category | Details |
|-----------|----------|
| **Engine** | Unity / Unreal Engine |
| **Perspective** | Third-Person |
| **Physics** | Rigidbody + Colliders |
| **Environment** | Static – same map for all levels |
| **Save System** | Progress auto-saves |
| **Platform** | Windows / macOS / Linux |

---

## 🧩 Future Roadmap

- Add cooperative multiplayer (two workers)
- Add forklift / conveyor system mechanics  
- Implement difficulty presets (Casual, Hard, Insane)  
- Add leaderboard and time-trial replay system  
- Introduce random object placement mode  

---

## 📸 Screenshots
<img width="1919" height="1069" alt="Screenshot 2025-11-01 182733" src="https://github.com/user-attachments/assets/8d35734e-0be9-4b26-ab75-d1572b3c2d68" />

<img width="1919" height="1079" alt="Screenshot 2025-11-01 182709" src="https://github.com/user-attachments/assets/ed2495f9-bd56-4211-aaa1-d10b12ebd84a" />

<img width="1919" height="1079" alt="Screenshot 2025-11-01 182657" src="https://github.com/user-attachments/assets/b55c984c-a8b3-4263-b127-3af2ba3e4080" />

<img width="1919" height="1079" alt="Screenshot 2025-11-01 182637" src="https://github.com/user-attachments/assets/5cdaf377-2de7-49d4-a49f-6ff41e85e092" />
