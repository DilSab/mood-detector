import React, { Component } from 'react';

export class AffectivaTest extends Component {
    displayName = AffectivaTest.name

    constructor(props) {
        super(props);
        this.state = { moods: [], loading: false };
    }

    componentWillMount() {
        this.setState({ loading: true });
        fetch('api/AffectivaTest/CheckPhoto')
            .then(response => response.json())
            .then(data => {
                this.setState({ moods: data, loading: false });
            });
    }

    sendPhoto() {
        var formData = new FormData();
        formData.append('name', 'Blaaaaaaaaah');
        formData.append('surname', 'Chaaaaaaaaaaa');
        fetch('api/AffectivaTest/CheckPhoto', {
            method: "post",
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                this.setState({ moods: data, loading: false });
                console.log(this.state.moods);
            });
    }

    render() {
        return (
            <div>
                <h1>Upload photo:</h1>
                <ul>
                    {this.state.moods.map(mood =>
                        <li key={mood.id}>Joy {mood.joy}; Anger {mood.anger}</li>
                    )}
                </ul>
                <input id="file" type="file" />
                <input type="submit" onClick={this.sendPhoto} />
            </div>
        );
    }
}