# ProjectX

![Progress](https://raw.githubusercontent.com/tonymtz/project-x/master/Promo%20images/Promo_gif_16.gif)

![Current state](https://raw.githubusercontent.com/tonymtz/project-x/2746c8a21a7897e630e889a64acec1f337a98c80/Promo%20images/promo_gif_13.gif)

![Previous state](https://raw.githubusercontent.com/tonymtz/project-x/89400913d8aa63c80489838506deb50732968ba8/Promo%20images/promo_12.gif)
![Previous state](https://raw.githubusercontent.com/tonymtz/project-x/1b69298740bc56a33138539ba0ebdfa733963246/Promo%20images/Promo_gif_8.gif)



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
