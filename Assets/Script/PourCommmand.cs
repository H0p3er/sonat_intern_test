public class PourCommmand
{
    private Bottle source;

    private Bottle target;

    public PourCommmand(Bottle source, Bottle target)
    {
        this.source = source;
        this.target = target;
    }

    public void Execute()
    {

        while (IsPourable(source, target))
        {
            target.Waters.Push(source.Waters.Pop());
        }
    }

    private bool IsPourable(Bottle source, Bottle target)
    {
        bool isNotPourableCondition = target.IsFull
            || !source.Waters.TryPeek(out Water soureFirstElement)
            || !soureFirstElement.Equals(target.Waters.Peek());

        return !isNotPourableCondition;
    }

}

