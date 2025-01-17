[<RequireQualifiedAccess>]
module InputText

open Feliz

type State =
  { InputText: string
    IsUpperCase: bool }

type Msg =
  | InputTextChanged of string
  | UppercaseToggled of bool

let init() =
  { InputText = ""
    IsUpperCase = false }

let update (inputTextMsg: Msg) (inputTextState: State) =
  match inputTextMsg with
  | InputTextChanged text -> { inputTextState with InputText = text }
  | UppercaseToggled upperCase -> { inputTextState with IsUpperCase = upperCase }

let render (state: State) (dispatch: Msg -> unit) =
  Html.div [
    Html.input [
      prop.valueOrDefault state.InputText
      prop.onChange (InputTextChanged >> dispatch)
    ]
    Common.divider
    Html.input [
      prop.id "uppercase-checkbox"
      prop.type'.checkbox
      prop.isChecked state.IsUpperCase
      prop.onChange (UppercaseToggled >> dispatch)
    ]
    Html.label [
      prop.htmlFor "uppercase-checkbox"
      prop.text "Uppercase"
    ]
    Html.h3 (if state.IsUpperCase then state.InputText.ToUpper() else state.InputText)
  ]
