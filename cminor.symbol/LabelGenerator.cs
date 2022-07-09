using System.Text;

namespace CMinor.Symbol;

public class LabelGenerator
{
    private string prefix;
    private int counter;

    public LabelGenerator(string prefix)
    {
        this.prefix = prefix;
        counter = 0;
    }

    public virtual string GetCurrentLabel() => (prefix) + ("_") + (counter++);
}
