class Player:
    speed = 1
    move_ticker = 0
    MAX_MOVE_TICK = 4

    def __init__(self, x, y):
        self.x = x
        self.y = y

    def update_move_ticker(self):
        if self.move_ticker == 0:
            self.move_ticker = self.MAX_MOVE_TICK
            return True
        else:
            self.move_ticker -= 1
            return False
