public class minerals : elements {

    private readonly int MAX_NESTED = 2;
    
    public minerals(int nestedBlock) {
        base(MAX_NESTED, nestedBlock);
    }
}