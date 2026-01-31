public enum Direction {
    None,
    Row,
    Col
}

[System.Serializable]
public struct Swipe {
    public Direction dir;
    public int way;
    public int index;
    public bool valid;

    public Swipe(Direction d, int w, int i, bool v) {
        dir = d;
        way = w;
        index = i;
        valid = v;
    }

    public override string ToString() {
        return "swipe: dir=" + dir +
               ", way=" + way +
               ", idx=" + index +
               ", vld=" + valid;
    }
}




