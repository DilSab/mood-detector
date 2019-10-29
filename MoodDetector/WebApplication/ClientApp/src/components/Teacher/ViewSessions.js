import React, { Component } from 'react';

export class ViewSessions extends Component {
    displayName = ViewSessions.name;

    constructor(props) {
        super(props);
        this.state = { moods: [], loading: false };
    }

    componentWillMount() {
        this.setState({ loading: true });
        fetch('api/ViewSessions/GetMoods')
            .then(response => response.json())
            .then(data => {
                this.setState({ moods: data, loading: false });
            });
    }

    render() {
        console.log(this.state.moods);

        return (
            <div>
                <ul>
                    {this.state.moods.map(mood =>
                        <li key={mood.id}>{mood.joy}</li>
                    )}
                </ul>
                <h1>View sessions window</h1>
                <p>here teacher can select sessions and see visuals</p>
            </div>
        )
    }
}