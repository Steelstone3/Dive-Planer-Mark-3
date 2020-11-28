﻿namespace DivePlannerMk3.Contracts
{
    interface IGasManagementController
    {
        int CalculateGasUsed(int depth, int time, int sacRate);

        int ConvertToBar( int cylinderTotalVolume, int cylinderSize );
    }
}