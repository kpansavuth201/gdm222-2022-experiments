import json

FILE_NAME = 'tiles.json'


def load_area_json():
    f = open('area.json', encoding="utf8")
    return json.load(f)


def load_rooms_json():
    f = open('rooms.json', encoding="utf8")
    return json.load(f)


def load_graphs_json():
    f = open('room_graphs.json', encoding="utf8")
    return json.load(f)


def write_to_json(data):
    with open(FILE_NAME, 'w') as f:
        json.dump(data, f, indent=4)


def check_room(x, y):
    for room in rooms:
        if (x >= room["x"] and
                x <= room["x"] + room["w"] and
                y >= room["y"] and
                y <= room["y"] + room["h"]):
            return True
    return False


rooms = load_rooms_json()
graphs = load_graphs_json()
area = load_area_json()
tiles = []
node = ""

# Assign rooms
for x in range(area["w"]):
    y_list = []
    for y in range(area["h"]):
        if check_room(x, y):
            node = "G"
        else:
            node = ""
        y_list.append(node)
    tiles.append(y_list)

# Assign corridors
open_list = graphs.copy()
while len(open_list) > 0:
    graph = open_list.pop()
    walker = [
        graph[0]["x"] + graph[0]["w"] // 2,
        graph[0]["y"] + graph[0]["h"] // 2
    ]
    target = [
        graph[1]["x"] + graph[1]["w"] // 2,
        graph[1]["y"] + graph[1]["h"] // 2
    ]
    while walker[0] != target[0]:
        if walker[0] < target[0]:
            walker[0] += 1
        else:
            walker[0] -= 1
        tiles[walker[0]][walker[1]] = "G"
    while walker[1] != target[1]:
        if walker[1] < target[1]:
            walker[1] += 1
        else:
            walker[1] -= 1
        tiles[walker[0]][walker[1]] = "G"


def up_node(x, y):
    if y == 0:
        return None
    return tiles[x][y-1]


def up_left_node(x, y):
    if y == 0 or x == 0:
        return None
    return tiles[x-1][y-1]


def up_right_node(x, y):
    if y == 0 or x == area["w"] - 1:
        return None
    return tiles[x+1][y-1]


def down_node(x, y):
    if y == area["h"] - 1:
        return None
    return tiles[x][y+1]


def down_left_node(x, y):
    if y == area["h"] - 1 or x == 0:
        return None
    return tiles[x-1][y+1]


def down_right_node(x, y):
    if y == area["h"] - 1 or x == area["w"] - 1:
        return None
    return tiles[x+1][y+1]


def left_node(x, y):
    if x == 0:
        return None
    return tiles[x-1][y]


def right_node(x, y):
    if x == area["w"] - 1:
        return None
    return tiles[x+1][y]


# Assign walls
WALL_CODE = "B"
for x in range(area["w"]):
    for y in range(area["h"]):
        if tiles[x][y] == "G" and up_node(x, y) == "":
            tiles[x][y-1] = WALL_CODE
        if tiles[x][y] == "G" and down_node(x, y) == "":
            tiles[x][y+1] = WALL_CODE
        if tiles[x][y] == "G" and left_node(x, y) == "":
            tiles[x-1][y] = WALL_CODE
        if tiles[x][y] == "G" and right_node(x, y) == "":
            tiles[x+1][y] = WALL_CODE
        if tiles[x][y] == "G" and up_right_node(x, y) == "":
            tiles[x+1][y-1] = WALL_CODE
        if tiles[x][y] == "G" and up_left_node(x, y) == "":
            tiles[x-1][y-1] = WALL_CODE
        if tiles[x][y] == "G" and down_right_node(x, y) == "":
            tiles[x+1][y+1] = WALL_CODE
        if tiles[x][y] == "G" and down_left_node(x, y) == "":
            tiles[x-1][y+1] = WALL_CODE

write_to_json(tiles)
