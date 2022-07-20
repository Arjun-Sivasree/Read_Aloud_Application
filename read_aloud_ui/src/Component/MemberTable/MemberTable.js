import React from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";

const MemberTable = (props) => {
  return (
    <TableContainer>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Name</TableCell>
            <TableCell>Phone number</TableCell>
            <TableCell>Job</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {props.memberData.map((element, index) => (
            <TableRow key={element.id}>
              <TableCell onClick={() => props.handleTableRowClick(index)}>
                {element.name}
              </TableCell>
              <TableCell onClick={() => props.handleTableRowClick(index)}>
                {element.phoneNumber}
              </TableCell>
              <TableCell onClick={() => props.handleTableRowClick(index)}>
                {element.job}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default MemberTable;
