import json
import random

FILE_NAME = 'rooms.json'
NUMBER_OF_ROOMS = 10
ROOM_MIN_SIZE = 10
ROOM_MAX_SIZE = 20
MAX_ATTEMP = 999


def load_area_json():
    f = open('area.json', encoding="utf8")
    return json.load(f)


def write_to_json(data):
    with open(FILE_NAME, 'w') as f:
        json.dump(data, f, indent=4)


rooms = []
area = load_area_json()
attemp = 0


def intersect(a, b):
    return (a["min_x"] - 1 <= b["max_x"] and
            a["max_x"] + 1 >= b["min_x"] and
            a["min_y"] - 1 <= b["max_y"] and
            a["max_y"] + 1 >= b["min_y"])


def check_overlap(check_room):
    for room in rooms:
        a = {}
        b = {}
        a["min_x"] = check_room["x"]
        a["max_x"] = check_room["x"] + check_room["w"]
        a["min_y"] = check_room["y"]
        a["max_y"] = check_room["y"] + check_room["h"]

        b["min_x"] = room["x"]
        b["max_x"] = room["x"] + room["w"]
        b["min_y"] = room["y"]
        b["max_y"] = room["y"] + room["h"]

        if intersect(a, b):
            return True
    return False


while len(rooms) < NUMBER_OF_ROOMS and attemp < MAX_ATTEMP:
    attemp += 1
    try_room = {
        "x": random.randint(0, area["w"] - ROOM_MIN_SIZE - 1),
        "y": random.randint(0, area["h"] - ROOM_MIN_SIZE - 1),
        "w": random.randint(ROOM_MIN_SIZE, ROOM_MAX_SIZE),
        "h": random.randint(ROOM_MIN_SIZE, ROOM_MAX_SIZE),
    }
    if (not check_overlap(try_room) and
            try_room["x"] + try_room["w"] < area["w"] and
            try_room["y"] + try_room["h"] < area["h"]):
        rooms.append(try_room)

write_to_json(rooms)