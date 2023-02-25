import React from "react";

export default class ColorChanger extends React.Component{
    constructor(props) {
        super(props);
        this.state = {
            bgColor: "black",
            textColor: "white"
        }
        this.onChange = this.onChange.bind(this);
    }
    onChange(bg, text){
        this.setState((prevState, props) =>{
            return {
                bgColor: bg,
                textColor: text
            }
        })
    }

    render() {
        return (<div className="color-changer">
            <p style={{color:this.state.textColor,backgroundColor:this.state.bgColor}}>COLORED TEXT</p>
            <button onClick={() => this.onChange("red", "green")}>Red/Green</button>
            <button onClick={() => this.onChange("yellow", "blue")}>Yellow/Blue</button>
            <button onClick={() => this.onChange("white", "black")}>White/Black</button>
        </div>)
    }
}