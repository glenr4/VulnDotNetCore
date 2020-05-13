import React, { Component } from "react";
import authService from "../api-authorization/AuthorizeService";
import "./FetchData.css";
import RadioButton from "../radio-button/RadioButton";

export class FetchData extends Component {
  static displayName = FetchData.name;
  option1 = "Easy";
  option2 = "Medium";
  option3 = "Hard";

  constructor(props) {
    super(props);
    this.state = {
      forecasts: [],
      loading: true,
      inputValue: "",
      method: this.option1,
    };
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
        <h1 id="tabelLabel">Weather forecast</h1>

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
          <div className="radio-btn-container radio-flex">
            <RadioButton
              changed={this.radioChangeHandler}
              isSelected={this.state.method === this.option1}
              label={this.option1}
              value={this.option1}
            />
            <RadioButton
              changed={this.radioChangeHandler}
              isSelected={this.state.method === this.option2}
              label={this.option2}
              value={this.option2}
            />
            <RadioButton
              changed={this.radioChangeHandler}
              isSelected={this.state.method === this.option3}
              label={this.option3}
              value={this.option3}
            />
          </div>
          {contents}
        </div>
      </>
    );
  }

  getWeather = async () => {
    if (event) {
      event.preventDefault();
    }

    const token = await authService.getAccessToken();
    const headers = new Headers();
    headers.append("Authorization", `Bearer ${token}`);
    headers.append("Content-Type", "application/json");

    fetch(
      `weatherforecast?query=${this.state.inputValue}&method=${this.state.method}`,
      {
        method: "get",
        headers: headers,
      }
    )
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        console.log("Response:");
        console.log(data);

        this.setState({ forecasts: data, loading: false });
      })
      .catch(() => {
        this.setState({ forecasts: [], loading: false });
      });
  };

  radioChangeHandler = () => {
    this.setState({ method: event.target.value });
  };
}
