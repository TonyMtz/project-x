# ProjectX


![Current state](https://raw.githubusercontent.com/tonymtz/project-x/1b69298740bc56a33138539ba0ebdfa733963246/Promo%20images/Promo_gif_8.gif)

![Progress](https://raw.githubusercontent.com/tonymtz/project-x/1b69298740bc56a33138539ba0ebdfa733963246/Promo%20images/Promo_gif_7.gif)

Trello Board:
https://trello.com/b/IHmhQEse/project-x

## Tools
Using Unity *5.3.3*

## Project Structure

I suggest to use this structure, so we can work better without mixing different assets:

- Animations
- Prefabs
- Scenes
- Scripts
- Sprites


## Best Practices

- Since scenes are saved as binaries, I think we can work better having all entities in prefabs and updating them instead of making modifications to the entities directly in the scene. In this fashion we can work at the same time in different scenes to avoid conflicts and reusing the same prefabs.
