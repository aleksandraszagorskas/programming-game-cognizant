import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div class="container">
            <form>
                <div class="form-group row">
                    <label for="participant-name" class="col-sm-3 col-form-label">NAME</label>
                    <div class="col-sm-9">
                        <input type="text" class="form-control" id="participant-name"/>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="task-select" class="col-sm-3 col-form-label">SELECT TASK</label>
                    <div class="col-sm-9">
                        <select class="form-control" id="task-select">
                            <option>Hello world task</option>
                        </select>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="description-textarea" class="col-sm-3 col-form-label">DESCRIPTION</label>
                    <div class="col-sm-9">
                        <textarea readonly class="form-control-plaintext" id="description-textarea" rows="5" value="Test task description"></textarea>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="description-textarea" class="col-sm-3 col-form-label">SOLUTION CODE</label>
                    <div class="col-sm-9">
                        <textarea class="form-control-plaintext" id="description-textarea" rows="7" ></textarea>
                    </div>
                </div>
                <div class="form-group row justify-content-end">
                    <div class="col-sm-9">
                        <button type="submit" class="btn btn-primary">SUBMIT</button>
                    </div>
                </div>
            </form>
        </div>
    );
  }
}
