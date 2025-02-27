# Hover Animations

You can use React components to implement hover animations for elements without writing any CSS. This is done by keeping track of a hover state flag and toggling it on or off when the mouse enters or leaves the elements. Here is an example:
```fsharp:hover-animations
let animationsOnHover' = React.functionComponent(fun (props: {| content: ReactElement |}) ->
    let (hovered, setHovered) = React.useState(false)
    Html.div [
        prop.style [
            style.padding 10
            style.transitionDuration (TimeSpan.FromMilliseconds 1000.0)
            style.transitionProperty [
                transitionProperty.backgroundColor
                transitionProperty.color
            ]

            if hovered then
               style.backgroundColor.lightBlue
               style.color.black
            else
               style.backgroundColor.limeGreen
               style.color.white
        ]
        prop.onMouseEnter (fun _ -> setHovered(true))
        prop.onMouseLeave (fun _ -> setHovered(false))
        prop.children [ props.content ]
    ])

let animationsOnHover content = animationsOnHover' {| content = Html.fragment content |}

Html.div [
    animationsOnHover [ Html.span "Hover me!" ]
    animationsOnHover [ Html.p "So smooth" ]
]
```