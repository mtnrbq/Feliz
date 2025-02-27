namespace Feliz.PigeonMaps

open Feliz
open Fable.Core
open Fable.Core.JsInterop

module Interop =
    /// Creates a map marker internally (which is actually `ReactElement`)
    let createMarker : obj -> IMapMarker = import "createMarker" "./Marker.js"

[<Erase>]
type PigeonMaps =
    static member inline map (properties: IReactProperty list) =
        // use defaults with center at Madrid and zoom at the whole world
        // this is because pigeon maps throws an exception when center isn't provided
        let defaults = createObj [
            "center" ==> [| 40.416775; -3.703790 |]
            "zoom" ==> 3
            "height" ==> 200
        ]

        Interop.reactApi.createElement(importDefault "pigeon-maps", JS.Object.assign(defaults, createObj !!properties))
    static member inline marker (properties: IReactProperty list) =
        Interop.createMarker (createObj !!properties)
