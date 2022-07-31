import React from "react";
import Grid from "@mui/material/Grid";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const navigate = useNavigate();

  const navigateToHome = () => {
    navigate("/");
  }

  const navigateToRegister = () => {
    navigate("/register");
  }

  return (
    <React.Fragment>
      <Grid
        container
        style={{
          height: "200px",
          textAlign: "center",
          backgroundColor: "#C3D4D2",
        }}
      >
        <Grid item xs={12}>
          <img src="read_aloud_logo3.png" alt="logo" height={"150px"} />
        </Grid>
        <Grid container item xs={12} justifyContent={"left"}>
          <Grid item xs={1}>
            <Button onClick={navigateToHome}>HOME</Button>
          </Grid>
          <Grid item xs={1}>
            <Button onClick={navigateToRegister}>REGISTER</Button>
          </Grid>
        </Grid>
      </Grid>
    </React.Fragment>
  );
}

export default Header;
