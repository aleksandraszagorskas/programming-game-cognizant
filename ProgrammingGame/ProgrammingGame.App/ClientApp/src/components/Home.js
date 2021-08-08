import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = {
            tasks: [],
            selectedTaskId: 0,
            participantName: '',
            solution: '',
            loading: true
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.renderForm = this.renderForm.bind(this);
        this.getSelectedTask = this.getSelectedTask.bind(this);
    }

    componentDidMount() {
        this.populateData();
    }

    handleChange = (event) => {
        let value = event.target.value;
        let name = event.target.name;

        this.setState({ [name]: value });
    }

    handleSubmit = async (event) => {
        event.preventDefault();

        let data = {
            ParticipantName: this.state.participantName,
            Solution: this.state.solution,
            TaskId: this.state.selectedTaskId
        }

        const response = await fetch('challenge/submitTask', {
            method: 'POST',
            body: JSON.stringify(data),
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }

    getSelectedTask = () => {
        let task = this.state.tasks.find((task) => task.taskId == this.state.selectedTaskId);
        return task;
    }

    renderForm = (tasks) => {
        return (
            <form onSubmit={this.handleSubmit}>
                <div className="form-group row">
                    <label htmlFor="participantName" className="col-sm-3 col-form-label">NAME</label>
                    <div className="col-sm-9">
                        <input type="text" name="participantName" value={this.state.participantName} onChange={this.handleChange} className="form-control" id="participantName" />
                    </div>
                </div>
                <div className="form-group row">
                    <label htmlFor="taskSelect" className="col-sm-3 col-form-label">SELECT TASK</label>
                    <div className="col-sm-9">
                        <select name="selectedTaskId" value={this.state.selectedTaskId} onChange={this.handleChange} className="form-control" id="taskSelect">
                            {tasks.map(task =>
                                <option key={task.taskId} value={task.taskId}>{task.name}</option>
                            )}
                        </select>
                    </div>
                </div>
                <div className="form-group row">
                    <label htmlFor="descriptionTextarea" className="col-sm-3 col-form-label">DESCRIPTION</label>
                    <div className="col-sm-9">
                        <textarea readOnly value={this.getSelectedTask().description} className="form-control-plaintext" id="descriptionTextarea" rows="5"></textarea>
                    </div>
                </div>
                <div className="form-group row">
                    <label htmlFor="solutionTextarea" className="col-sm-3 col-form-label">SOLUTION CODE</label>
                    <div className="col-sm-9">
                        <textarea name="solution" value={this.state.solution} onChange={this.handleChange} className="form-control" id="solutionTextarea" rows="7" ></textarea>
                    </div>
                </div>
                <div className="form-group row justify-content-end">
                    <div className="col-sm-9">
                        <button type="submit" className="btn btn-primary">SUBMIT</button>
                    </div>
                </div>
            </form>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderForm(this.state.tasks);

        return (
            <div className="container">
                {contents}
            </div>
        );
    }

    async populateData() {
        const response = await fetch('challenge/tasks');
        const data = await response.json();
        this.setState({ tasks: data, selectedTaskId: data[0].taskId, loading: false });
    }
}
