#include <stdio.h>

const int COLMAX = 16;
const int ROWMAX = 16;

void FloodFill(int col, int row, int selection, int fillColor, int map[][COLMAX]);

int MMain()
{
	int map[ROWMAX][COLMAX]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0,
		0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0,
		0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
	};
	FloodFill(0, 8, 0, 2, map);

	for (int i = 0; i < COLMAX; i++)
	{
		for (int j = 0; j < ROWMAX; j++)
		{
			printf("%d ", map[j][i]);
		}
		printf("\n");
	}
	return 0;
}

void FloodFill(int col, int row, int selection, int fillColor, int map[][COLMAX])
{
	if (row >= ROWMAX || col >= COLMAX || row < 0 || col < 0)
	{
		return;
	}
	else if (map[row][col] != selection)
	{
		return;
	}
	map[row][col] = fillColor;

	FloodFill(col + 1, row, selection, fillColor, map);
	FloodFill(col - 1, row, selection, fillColor, map);
	FloodFill(col, row + 1, selection, fillColor, map);
	FloodFill(col, row - 1, selection, fillColor, map);
}
