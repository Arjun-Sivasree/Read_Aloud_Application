import React from "react";
import "./App.css";
import Grid from "@mui/material/Grid";
import Body from "./Component/Body/Body";
import Header from "./Component/Header/Header";

function App() {
  return (
    <React.Fragment>
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <Header />
        </Grid>
        <Grid item xs={12}>
          <Body />
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default App;
