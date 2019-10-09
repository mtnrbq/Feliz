[<RequireQualifiedAccess>]
module Samples.Recharts.LineCharts.BiaxialLineChart

open Feliz
open Feliz.Recharts
open Fable.Core.Experimental

type Point = { name: string; uv: int; pv: int; }

let data = [
    { name = "Page A"; uv = 4000; pv = 2400 }
    { name = "Page B"; uv = 3000; pv = 1398 }
    { name = "Page C"; uv = 2000; pv = 9800 }
    { name = "Page D"; uv = 2780; pv = 3908 }
    { name = "Page E"; uv = 1890; pv = 4800 }
    { name = "Page F"; uv = 2390; pv = 3800 }
    { name = "Page G"; uv = 3490; pv = 4300 }
]

let chart = React.functionComponent <| fun () ->
    Recharts.lineChart [
        lineChart.width 500
        lineChart.height 300
        lineChart.data data
        lineChart.margin(top=5, right=30)
        lineChart.children [
            Recharts.cartesianGrid [ cartesianGrid.strokeDasharray(3, 3) ]
            Recharts.xAxis [ xAxis.dataKey (fun p -> nameof p.name) ]
            Recharts.yAxis [ yAxis.yAxisId "left" ]
            Recharts.yAxis [ yAxis.yAxisId "right"; yAxis.orientation.right ]
            Recharts.tooltip [ ]
            Recharts.legend [ ]
            Recharts.line [
                line.yAxisId "left"
                line.monotone
                line.dataKey (fun point -> nameof point.pv)
                line.stroke "#8884d8"
            ]

            Recharts.line [
                line.yAxisId "right"
                line.monotone
                line.dataKey (fun point -> nameof point.uv)
                line.stroke "#82ca9d"
            ]
        ]
    ]