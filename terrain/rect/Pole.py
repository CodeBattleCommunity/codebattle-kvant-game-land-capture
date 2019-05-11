import os
import sys
import pygame

pygame.init()

FPS = 50
WIDTH = 750
HEIGHT = 550
screen = pygame.display.set_mode((WIDTH, HEIGHT))
clock = pygame.time.Clock()
all_sprites = pygame.sprite.Group()
tiles_group = pygame.sprite.Group()


def load_image(name, color_key=None):
    fullname = os.path.join('data', name)
    try:
        image = pygame.image.load(fullname)
    except pygame.error as message:
        print('Cannot load image:', name)
        raise SystemExit(message)
    image = image.convert_alpha()

    if color_key is not None:
        if color_key is -1:
            color_key = image.get_at((0, 0))
        image.set_colorkey(color_key)
    return image


def load_level(filename):
    filename = "data/" + filename
    with open(filename, 'r') as mapFile:
        level_map = [line.strip() for line in mapFile]
    max_width = max(map(len, level_map))
    return list(map(lambda x: x.ljust(max_width, '.'), level_map))


def generate_level(level):
    x, y = None, None
    for y in range(len(level)):
        for x in range(len(level[y])):
            if level[y][x] == '.':
                Tile('empty', x, y)

    return x, y


tile_images = {'empty': load_image('kletka.png')}
tile_width = tile_height = 50


class Tile(pygame.sprite.Sprite):
    def __init__(self, tile_type, pos_x, pos_y):
        super().__init__(tiles_group, all_sprites)
        self.image = tile_images[tile_type]
        self.rect = self.image.get_rect().move(tile_width * pos_x, tile_height * pos_y)


class Point(pygame.sprite.Sprite):
    image = pygame.transform.scale(load_image("p.png"), (10, 10))

    def __init__(self, group, x, y):
        super().__init__(group)
        self.image = Point.image
        self.rect = self.image.get_rect()
        self.rect.x = x
        self.rect.y = y


level_x, level_y = generate_level(load_level("levelex.txt"))

running = True
for i in range(12):
    for j in range(12):
        if i == 6 and j == 6 or i == 5 and j == 5 or i == 6 and j == 5 or i == 5 and j == 6:
            Point(all_sprites, -50, -50)
        else:
            Point(all_sprites, i * 50-5, j * 50 - 5)

while running:

    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
    screen.fill(pygame.Color(165, 42, 42))
    tiles_group.draw(screen)
    all_sprites.draw(screen)
    pygame.display.flip()
    clock.tick(FPS)

pygame.quit()
