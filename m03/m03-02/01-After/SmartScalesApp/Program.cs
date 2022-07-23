using SmartScalesApp.ConsoleUI;

bool showMenu = true;
while (showMenu)
{
    showMenu = new ConsoleUIMenus().Run();
}