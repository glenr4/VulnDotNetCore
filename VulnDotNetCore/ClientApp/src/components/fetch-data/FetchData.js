import React, { Component } from "react";
import authService from "../api-authorization/AuthorizeService";
import "./FetchData.css";

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true, inputValue: "" };
  }

  componentDidMount() {
    this.getWeather();
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className="table table-striped" aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>City</th>
            <th>Temp. (C)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.cityName}>
              <td>{forecast.cityName}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.forecast}</td>
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
        <form onSubmit={this.getWeather}>
          <label>
            Name:
            <input
              className={"search-input"}
              value={this.state.inputValue}
              onChange={(evt) =>
                this.setState({ inputValue: evt.target.value })
              }
            />
          </label>
          <input type="submit" value="Search" />
        </form>
        <div>
          <h1 id="tabelLabel">Weather forecast</h1>
          {contents}
        </div>
      </>
    );
  }

  getWeather = async () => {
    if (event) {
      event.preventDefault();
    }

    const self = this;
    const token = await authService.getAccessToken();
    const headers = new Headers();
    headers.append("Authorization", `Bearer ${token}`);
    headers.append("Content-Type", "application/json");

    fetch(`weatherforecast?query=${this.state.inputValue}`, {
      method: "get",
      headers: headers,
    })
      .then(function (response) {
        return response.json();
      })
      .then(function (data) {
        console.log("Response:");
        console.log(data);

        self.setState({ forecasts: data, loading: false });
      });
  };
}
