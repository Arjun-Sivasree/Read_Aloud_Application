import React from "react";
import "./App.css";
import { Grid } from "@mui/material";
import Header from "./Component/Header/Header";
import Home from "./Component/Home/Home";
import Register from "./Component/Register/Register";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
  return (
    <React.Fragment>
      <BrowserRouter>
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <Header />
          </Grid>
          <Grid item xs={12}>
            <Routes>
              <Route path="/register" element={<Register />}></Route>
              <Route path="/" exact element={<Home />}></Route>
            </Routes>
          </Grid>
        </Grid>
      </BrowserRouter>
    </React.Fragment>
  );
}

export default App;
