

import json
import sys

FILE_NAME = 'room_graphs.json'


def load_rooms_json():
    f = open('rooms.json', encoding="utf8")
    return json.load(f)


def write_to_json(data):
    with open(FILE_NAME, 'w') as f:
        json.dump(data, f, indent=4)


rooms = load_rooms_json()


def find_dist(room_a, room_b):
    center_a = [
        room_a["x"] + room_a["w"] // 2,
        room_a["y"] + room_a["h"] // 2
    ]
    center_b = [
        room_b["x"] + room_b["w"] // 2,
        room_b["y"] + room_b["h"] // 2
    ]
    return abs(center_a[0] - center_b[0]) + abs(center_a[1] - center_b[1])


def find_closest_node(cur_node, node_list):
    closest_node = None
    min_dist = sys.maxsize
    for node in node_list:
        dist = find_dist(cur_node, node)
        if dist < min_dist:
            min_dist = dist
            closest_node = node
    return closest_node


def create_graph():
    graphs = []
    open_list = rooms.copy()
    cur_node = open_list.pop()
    while len(open_list) > 0:
        if len(open_list) == 1:
            graphs.append(
                [
                    cur_node,
                    open_list.pop()
                ]
            )
        else:
            closest_node = find_closest_node(cur_node, open_list)
            graphs.append(
                [
                    cur_node,
                    closest_node
                ]
            )
            cur_node = closest_node
            open_list.remove(closest_node)
    return graphs


write_to_json(create_graph())
