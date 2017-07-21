using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    public enum Mode : int
    {
        _value = 0,
        _not = 1,
        _random = 2,
        _normal = 0,
        _unknownFromStart = 256, // these values are easier to use in assembly since AL = fill_mode and AH = range_mode
        _unknownFromEnd = 512
    }
    public enum ThreeButtonsWindowAction : int
    {
        _firstButton = 0,
        _secondButton = 1,
        _ThirdButton = 2,
    }
    public enum RangeAction
    {
        _defaultrange = 0,
        _fixedrange = 1,
        _cancel = 2
    }
    public enum NextRange
    {
        _first = 0,
        _last = 1,
        _random =2
    }
}
