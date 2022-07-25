import React, { useState } from "react";
import { RegisterNewMember } from "../Axios/_axios";
import { Grid, TextField, Typography, Button } from "@mui/material";

const Register = () => {
  const [formData, setFormData] = useState({
    name: "",
    age: "",
    address: "",
    phoneNumber: "",
    job: "",
    emailId: "",
  });

  const handleFormEntry = (event) => {
    let modifiedFormData = { ...formData };
    modifiedFormData[event.target.name] = event.target.value;

    setFormData(modifiedFormData);
  };

  const handleRegistration = async () => {
    //api integration to save the data
    await RegisterNewMember(formData);
  };

  return (
    <React.Fragment>
      <Grid
        container
        spacing={2}
        paddingTop={"50px"}
        paddingLeft={"250px"}
        paddingRight={"250px"}
      >
        <Grid item xs={12}>
          <Typography variant="h6">Please register the new member</Typography>
        </Grid>
        <Grid item xs={4}>
          <TextField
            name="name"
            label="Name"
            variant="outlined"
            size="small"
            fullWidth={true}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={1}>
          <TextField
            name="age"
            label="Age"
            variant="outlined"
            size="small"
            fullWidth={true}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={4}>
          <TextField
            name="phoneNumber"
            label="Phone Number"
            variant="outlined"
            size="small"
            fullWidth={true}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={3}>
          <TextField
            name="emailId"
            label="Email Id"
            variant="outlined"
            size="small"
            fullWidth={true}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={9}>
          <TextField
            name="address"
            multiline={true}
            label="Address"
            variant="outlined"
            size="small"
            fullWidth={true}
            rows={4}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={3}>
          <TextField
            name="job"
            label="Job"
            variant="outlined"
            size="small"
            fullWidth={true}
            onChange={handleFormEntry}
          />
        </Grid>
        <Grid item xs={12} style={{ textAlign: "center" }}>
          <Button onClick={handleRegistration} variant={"outlined"}>
            Register
          </Button>
        </Grid>
      </Grid>
    </React.Fragment>
  );
};

export default Register;
