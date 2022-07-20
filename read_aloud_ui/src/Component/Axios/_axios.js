import axios from "axios";

const _axios = axios.create({
  baseURL: "https://localhost:7144/api/Member/",
  headers: { "content-type": "application/json" },
});

export async function getAllMembersAndAssignments() {
  let response = await _axios.get("GetMembersAndAssignments");
  return response;
}
