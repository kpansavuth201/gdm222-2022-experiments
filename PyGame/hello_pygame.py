import pygame

pygame.init()

BLACK = (0,0,0)
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600

screen_size = (SCREEN_WIDTH, SCREEN_HEIGHT)
screen = pygame.display.set_mode(screen_size)
pygame.display.set_caption("My first PyGame")

clock = pygame.time.Clock()

running = True

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    screen.fill(BLACK)

    pygame.draw.rect(screen, (255,0,0), pygame.Rect(30, 30, 60, 60))

    pygame.display.flip()

    clock.tick(60)

pygame.quit()
