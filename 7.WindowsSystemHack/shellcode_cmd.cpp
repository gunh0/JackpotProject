#include "windows.h"

void main()
{
	char cmd[4] = { 'c','m','d','\x0' };
	WinExec(cmd, SW_SHOW);
	ExitProcess(1);
}