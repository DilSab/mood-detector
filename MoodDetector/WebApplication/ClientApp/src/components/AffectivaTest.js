import React, { Component } from 'react';

export class AffectivaTest extends Component {
    displayName = AffectivaTest.name

    constructor(props) {
        super(props);
        this.state = { moods: [], loading: true };

        
    }

    static renderMoodsDisplay(moods) {

        fetch('api/AffectivaTest/CheckPhoto')
            .then(response => response.json())
            .then(data => {
                console.log("Blahhhhhhhhhh");
                this.setState({ moods: data, loading: false });
            });

        return (
            <div>
                <p>Joy: {moods.Joy}</p>
                <p>Anger: {moods.Anger}</p>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p> Loading...</p>
            : AffectivaTest.renderMoodsDisplay(this.state.moods);

        return (
            <div>
                <h1>Upload photo:</h1>
                <input id="file" type="file" />
                <input type="submit" onClick={this.sayHello} />
                {contents}
            </div>
        );
    }
}