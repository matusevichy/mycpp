#include "Player.h"

Player::Player()
{
	score = 100;
}

void Player::operator++()
{
	score += 1000;
}

void Player::operator--()
{
	score -= 1;
}
