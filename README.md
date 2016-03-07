# project-x

Trello Board:
https://trello.com/b/IHmhQEse/project-x

## Tools
Using Unity *5.3.3*

## Project Structure

I suggest to use this structure, so we can work better without mixing different assets:

- Prefabs
- Scripts
- Sprites
- Animations
- Scenes

## Best Practices

- Since scenes are saved thru binaries, I think we can work better having all entities in prefabs and updating them instead of making modifications to the entities directly in the scene. In this fashion we can work at the same time in different scenes to avoid conflicts and reusing the same prefabs.
