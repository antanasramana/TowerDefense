﻿using TowerDefense.Api.Battle.Grid;

namespace TowerDefense.Api.Contracts.Grid
{
    public class GetGridResponse
    {
        public GetGridItemResponse[] GridItems { get; set; }
    }
}