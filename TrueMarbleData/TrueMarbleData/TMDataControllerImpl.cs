using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TrueMarbleData
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class TMDataControllerImpl : ITMDataController
    {
        public int GetNumTilesAcross(int zoom)
        {
            int tileX = 0;
            int tileY;
            int result;

            try
            {
                result = TMDLLWrapper.GetNumTiles(zoom, out tileX, out tileY);

                if (result == 0)
                {
                    throw new Exception(" retreving error");
                }
                return tileX;
            }
            catch (System.DllNotFoundException)
            {
                Console.WriteLine("Dll Not Found");
                return 0;
            }

        }

        public int GetNumTilesDown(int zoom)
        {
            int tileX = 0;
            int tileY;
            int result;

            try
            {
                result = TMDLLWrapper.GetNumTiles(zoom, out tileX, out tileY);

                if (result == 0)
                {
                    throw new Exception(" retreving error");
                }
                return tileY;
            }
            catch (System.DllNotFoundException)
            {
                Console.WriteLine("Dll Not Found");
                return 0;
            }
        }

        public int GetTileHeight()
        {
            int width;
            int height;
            int result;
            try
            {
                result = TMDLLWrapper.GetTileSize(out width, out height);
                if (result == 0)
                {
                    throw new Exception("retreving height error");
                }
                return height;
            }
            catch (System.DllNotFoundException)
            {
                Console.WriteLine("Dill Not Found");
                return 0;
            }

        }

        public int GetTileWidth()
        {
            int width;
            int height;
            int result;
            try
            {
                result = TMDLLWrapper.GetTileSize(out width, out height);
                if (result == 0)
                {
                    throw new Exception("retreving width error");
                }
                return width;
            }
            catch (System.DllNotFoundException)
            {
                Console.WriteLine("Dill Not Found");
                return 0;
            }
        }

        public byte[] LoadTile(int zoom, int x, int y)
        {
            try
            {
                int width;
                int height;
                int jpgSize;
                int sizeRes;
                int result;

                sizeRes = TMDLLWrapper.GetTileSize(out width, out height);
                byte[] buff = new byte[width * height * 3];

                result = TMDLLWrapper.GetTileImageAsRawJPG(zoom, x, y, out buff, width * height * 3, out jpgSize);

                if (result == 1)
                {
                    return buff;
                }

                else
                {
                    return null;
                }


            }
            catch (System.DllNotFoundException)
            {
                Console.WriteLine("Dill Not Found");
                return null;

            }


        }
    }
}
