import React from "react";
import Grid from "@mui/material/Grid";
//import { Button } from "@mui/material";

const Header = () => {
  return (
    <React.Fragment>
      <Grid
        container
        style={{
          height: "150px",
          textAlign: "center",
          backgroundColor: "#C3D4D2",
        }}
      >
        <Grid item xs={12}>
          <img src="read_aloud_logo3.png" alt="logo" height={"150px"} />
        </Grid>
        {/* <Grid container item xs={12}>
          <Grid item xs={3}>
            <Button>HOME</Button>
          </Grid>
        </Grid> */}
      </Grid>
    </React.Fragment>
  );
};

export default Header;
