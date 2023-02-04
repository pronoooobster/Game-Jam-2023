public class water : elements {

    private readonly int MAX_NESTED = 4;
    
    public water(int nestedBlock) {
        base(MAX_NESTED, nestedBlock);
    }
}