public abstract class Element {

    private readonly int MAX_NESTED; // the maximum amount of the element that can be in the vein
    private int absorbedAmount; // the amount you get when you deplete the node
    private int nestedBlock; // idk if you have a vein (more than 1 block of smth) if it is 0 then its not an element
    
    // *TODO* WE NEED TO DECIDE SPAWN RATE OF ELEMENTS!!!
    Element(int MAX_NESTED, int nestedBlock) {
        this.MAX_NESTED = MAX_NESTED;
        this.absorbedAmount = 0;
        this.nestedBlock = nestedBlock;
    }
    public int getAbsorbedAmount() {
        return this.absorbedAmount;
    }
    public int getNested() {
        return this.nestedBlock;
    }
  
}