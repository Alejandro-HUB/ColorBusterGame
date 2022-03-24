using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorBuster
{
    public class BoardModel
    {
        List<TileModel> checkedTiles { get; set; }
        List<TileModel> TilestoCheck { get; set; }
        bool movesAvailable { get; set; }
    }
}
