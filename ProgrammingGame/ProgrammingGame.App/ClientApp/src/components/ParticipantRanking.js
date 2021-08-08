import React, { Component } from 'react';

export class ParticipantRanking extends Component {
    static displayName = ParticipantRanking.name;

    constructor(props) {
        super(props);
        this.state = { rankings: [], loading: true };

        this.renderTable = this.renderTable.bind(this);
    }

    componentDidMount() {
        this.populateData();
    }

    renderTable = (rankings) => {
        return (
            <div>
                <h1 id="tableLabel" >Top {this.state.rankings.length} Participants</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Place</th>
                            <th>Participant Name</th>
                            <th>Time</th>
                        </tr>
                    </thead>
                    <tbody>
                        {rankings.map(ranking =>
                            <tr key={ranking.entryId}>
                                <td>{rankings.indexOf(ranking) + 1}</td>
                                <td>{ranking.participantName}</td>
                                <td>{ranking.time}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderTable(this.state.rankings);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('challenge/rankings');
        const data = await response.json();
        this.setState({ rankings: data, loading: false });
    }
}
