import json

FILE_NAME = 'area.json'
W = 96
H = 60


def write_to_json(data):
    with open(FILE_NAME, 'w') as f:
        json.dump(data, f, indent=4)


write_to_json(
    {
        "w": W,
        "h": H
    }
)
