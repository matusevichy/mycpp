import React from "react";

class GreatPerson extends React.Component{
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="great-person">
                <div className="pib">
                    <h3>{this.props.person.firstName} {this.props.person.middleName} {this.props.person.lastName}</h3>
                </div>
                <div className="birth-date">
                    {this.props.person.birthDate}
                </div>
                <div className="photo">
                    {<img src={this.props.person.photo} /> }
                </div>
                <div className="biography">
                    {this.props.person.biography }
                </div>
            </div>
        )
    }
}

export default GreatPerson;