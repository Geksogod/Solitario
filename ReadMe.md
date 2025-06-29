# Solitario 

## Description

This is a mini-feature prototype for a Solitaire-style mobile game. The goal was to implement a basic **Undo Move** system in Unity. You can drag cards between stacks and undo your move.

---

## Features

- **Drag-and-drop** cards between stacks on the Canvas
- **Undo** — revert the last move (returns the card to its previous stack)
- Minimal, modular architecture (clean interfaces, single-responsibility code)
- Ready for extension with new actions or additional features
- Uses SignalBus and Zenject for dependency injection and event management

---

## How it works

1. The player drags a card from one stack to another.
2. Each move is stored in a stack of actions.
3. When **Undo** is pressed, the last move is reverted and the card returns to its previous location.

---

## Possible improvements

- **Multiple Undo/Redo** (full move history)
- Complete Solitaire rules and card layout logic
- Animations, visual feedback, and sound
- Automated tests for Undo/Redo system
- UI to display move history

---

## AI Assistance

- **Code for the Editor was written with the help of ChatGPT.**