import React, { useState } from 'react';
import MaterialTable from 'material-table';
import './App.css';
import { CircularProgress } from '@material-ui/core';

function App() {

  const [teams, setTeams] = useState([]);
  const [lookup, setLookup] = useState({});

  const loadTeams = () => {
    let url = 'https://pwbe-cotemig.mybluemix.net/api/Teams';
    fetch(url)
      .then(response => response.json())
      .then(result => {
        let temp: any = {};
        result.map((team: any) => {
          temp[team.id] = team.name;
        });
        setLookup(temp);
        setTeams(result);
      })
  }

  if (!teams.length) {
    loadTeams();
  }

  if (teams.length && Object.keys(lookup).length) {
    return (
      <div>
        <MaterialTable
          title="Teams"
          columns={[
            {
              title: 'ID',
              field: 'id',
              editable: 'never',
            },
            {
              title: 'Name',
              field: 'name',
            },
            {
              title: 'Athletes Count',
              field: 'athletes',
              editable: 'never',
              render: (rowData: any) => rowData && rowData.athletes.length
            },
          ]}
          data={teams}
          editable={{
            onRowAdd: newData =>
              new Promise(async (resolve, reject) => {
                const rawResponse = await fetch('https://pwbe-cotemig.mybluemix.net/api/Teams', {
                  method: 'POST',
                  headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
                  body: JSON.stringify(newData)
                });
                await rawResponse.json();
                loadTeams();
                resolve();
              }),
            onRowUpdate: (newData, oldData) =>
              new Promise(async (resolve, reject) => {
                const rawResponse = await fetch('https://pwbe-cotemig.mybluemix.net/api/Teams', {
                  method: 'PUT',
                  headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                  },
                  body: JSON.stringify(newData)
                });
                await rawResponse.json();
                loadTeams();
                resolve();
              }),
            onRowDelete: oldData =>
              new Promise(async (resolve, reject) => {
                const rawResponse = await fetch(`https://pwbe-cotemig.mybluemix.net/api/Teams?id=${oldData.id}`, {
                  method: 'DELETE',
                });
                await rawResponse.json();
                loadTeams();
                resolve();
              })
          }}
        />
        <MaterialTable
          title="Athletes"
          columns={[{
            title: 'Id',
            field: 'id',
            editable: 'never',
          },
          {
            title: 'Name',
            field: 'name',
          },
          {
            title: 'Position',
            field: 'position',
          },
          {
            title: 'Type',
            field: 'type',
          },
          {
            title: 'Birthdate',
            field: 'birthdate',
            type: 'date',
            render: (rowData: any) => new Date(rowData.birthdate).toLocaleDateString('pt-br'),
          },
          {
            title: 'Team',
            field: 'team',
            render: (rowData: any) => rowData.team.name,
            lookup: lookup,
          },
          ]}
          data={query =>
            new Promise((resolve, reject) => {
              let url = 'https://pwbe-cotemig.mybluemix.net/api/Athletes';
              fetch(url)
                .then(response => response.json())
                .then(result => {
                  resolve({
                    data: result,
                    page: 0,
                    totalCount: result.length,
                  })
                })
            })
          }
          editable={{
            onRowAdd: newData =>
              new Promise((resolve, reject) => {
                setTimeout(() => {
                  {
                    /* const data = this.state.data;
                    data.push(newData);
                    this.setState({ data }, () => resolve()); */
                  }
                  resolve();
                }, 1000);
              }),
            onRowUpdate: (newData, oldData) =>
              new Promise((resolve, reject) => {
                setTimeout(() => {
                  {
                    /* const data = this.state.data;
                    const index = data.indexOf(oldData);
                    data[index] = newData;                
                    this.setState({ data }, () => resolve()); */
                  }
                  resolve();
                }, 1000);
              }),
            onRowDelete: oldData =>
              new Promise((resolve, reject) => {
                setTimeout(() => {
                  {
                    /* let data = this.state.data;
                    const index = data.indexOf(oldData);
                    data.splice(index, 1);
                    this.setState({ data }, () => resolve()); */
                  }
                  resolve();
                }, 1000);
              })
          }}
        />
      </div>
    );
  }

  return (
    <div style={{
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center'
    }}
      className="progress-circle">
      <CircularProgress style={{
      }} />
    </div>);
}

export default App;
