import React, { Component } from "react";
import authService from "./api-authorization/AuthorizeService";

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading ? (
      <p>
        <em>Loading...</em>
      </p>
    ) : (
      FetchData.renderForecastsTable(this.state.forecasts)
    );

    return (
      <>
        <form onSubmit={this.handleSubmit}>
          <label>
            Name:
            <input
              value={this.state.inputValue}
              onChange={evt => this.setState({ inputValue: evt.target.value })}
            />
          </label>
          <input type="submit" value="Submit" />
        </form>
        <div>
          <h1 id="tabelLabel">Weather forecast</h1>
          <p>This component demonstrates fetching data from the server.</p>
          {contents}
        </div>
      </>
    );
  }

  handleSubmit = async () => {
    event.preventDefault();

    const token = await authService.getAccessToken();
    const headers = new Headers();
    headers.append("Authorization", `Bearer ${token}`);
    headers.append("Content-Type", "application/json");

    fetch(`weatherforecast/test?query=${this.state.inputValue}`, {
      method: "get",
      headers: headers
    })
      .then(function(response) {
        return response.json();
      })
      .then(function(data) {
        console.log("Response:");
        console.log(data);
      });
  };

  async populateWeatherData() {
    const token = await authService.getAccessToken();
    const response = await fetch("weatherforecast", {
      headers: !token ? {} : { Authorization: `Bearer ${token}` }
    });
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
