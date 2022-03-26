import pygame
import json
import os
from player import Player


def load_config_json():
    f = open('config.json', encoding="utf8")
    return json.load(f)


def load_area_json():
    f = open('area.json', encoding="utf8")
    return json.load(f)

def load_rooms_json():
    f = open('rooms.json', encoding="utf8")
    return json.load(f)


def load_tiles_json():
    f = open('tiles.json', encoding="utf8")
    return json.load(f)


config = load_config_json()
area = load_area_json()
rooms = load_rooms_json()
tiles = load_tiles_json()
running = True
size = (
    config['screen']['width'],
    config['screen']['height']
)
TILE_SIZE_X = config['screen']['width'] // area["w"]
TILE_SIZE_Y = config['screen']['height'] // area["h"]
tile_color_map = {
    "": "black",
    "R": "red",
    "G": "green",
    "B": "blue",
    "W": "white"
}
player = Player(rooms[0]["x"], rooms[0]["y"])

pygame.init()
screen = pygame.display.set_mode(size)
pygame.display.set_caption("Procedural Generation Game")
clock = pygame.time.Clock()


def check_quit():
    global running
    global tiles
    for event in pygame.event.get():  # User did something
        if event.type == pygame.QUIT:  # If user clicked close
            running = False  # Flag that we are done so we exit this loop
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_r:
                os.system('python3 create_rooms.py')
                os.system('python3 create_room_graph.py')
                os.system('python3 create_tiles.py')
                tiles = load_tiles_json()
    if player.update_move_ticker():
        keys = pygame.key.get_pressed()
        next_x = player.x + (keys[pygame.K_RIGHT] - keys[pygame.K_LEFT]) * player.speed
        next_y = player.y + (keys[pygame.K_DOWN] - keys[pygame.K_UP]) * player.speed
        if 0 <= next_x < area["w"] and 0 <= next_y < area["h"]:
            if tiles[next_x][next_y] == "G":
                player.x = next_x
                player.y = next_y


def draw():
    color = "black"
    for y in range(area["h"]):
        for x in range(area["w"]):
            if x == player.x and y == player.y:
                color = "red"
            else:
                color = tile_color_map[tiles[x][y]]
            pygame.draw.rect(
                screen,
                config['colors'][color],
                pygame.Rect(x * TILE_SIZE_X, y * TILE_SIZE_Y, TILE_SIZE_X-2, TILE_SIZE_Y-2)
            )


while running:
    check_quit()
    screen.fill(config['colors']['black'])

    draw()

    pygame.display.flip()
    clock.tick(60)

pygame.quit()
