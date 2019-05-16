public static class GameStores
{
    public static int BreadQuantity { get; set; }
    public static int Choice1 { get; set; } // 0 = not encountered yet 1 = night, 2 = day
    public static int Choice2 { get; set; } // 0 = not encountered yet 1 = NOT pay 2 = pay bread 
    public static int Choice3 { get; set; } // 0 = not encountered yet 1 = NOT pay 2 = pay to get key 
    public static int Choice4 { get; set; } // ending choice, having cut off finger: 0 = not encountered yet 1 = not eat bread 2 = eat bread
    public static int levelBread;


    static GameStores()
    {
        BreadQuantity = 0;
        Choice1 = 0;
        Choice2 = 0;
        Choice3 = 0;
        Choice4 = 0;
    }

    public static void changeScene()
    {
        levelBread = 0;
    }
}
